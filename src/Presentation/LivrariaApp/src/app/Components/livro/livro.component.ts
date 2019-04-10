import { Component, OnInit } from "@angular/core";

import { Observable } from "rxjs";

import { Livro } from "src/app/Models/livro.models";

import { FormBuilder, Validators } from "@angular/forms";

import { LivroService } from "src/app/Services/livro.service";

@Component({
  selector: 'app-livro',
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css']
})
export class LivroComponent implements OnInit {
  dataSaved = false;
  livroForm: any;
  allLivros: Observable<Livro[]>;
  livroIdUpdate = null;
  massage = null;

  constructor(private formbulider: FormBuilder, private livroService: LivroService) { }

  ngOnInit() {
    this.livroForm = this.formbulider.group({
      Titulo: ['', [Validators.required]],
      NumeroDePaginas: ['', [Validators.required]],
      Edicao: ['', [Validators.required]],
      Ano: ['', [Validators.required]],
      Descricao: ['', [Validators.required]]
    });
    this.loadAllLivros();
  }

  loadAllLivros() {
    this.allLivros = this.livroService.ListarLivros();
  }

  onFormSubmit() {
    this.dataSaved = false;
    const livro = this.livroForm.value;
    this.CreateLivro(livro);
    this.livroForm.reset();
  }

  loadLivroToEdit(livroId: number) {
    this.livroService.getLivroById().subscribe(livro => {
      this.massage = null;
      this.dataSaved = false;
      this.livroIdUpdate = livro.Id;
      this.livroForm.controls['Titulo'].setValue(livro.Titulo);
      this.livroForm.controls['NumeroDePaginas'].setValue(livro.NumeroDePaginas);
      this.livroForm.controls['Edicao'].setValue(livro.Edicao);
      this.livroForm.controls['Ano'].setValue(livro.Ano);
      this.livroForm.controls['Descricao'].setValue(livro.Descricao);
    });
  }

  CreateLivro(livro: Livro) {
    if (this.livroIdUpdate == null) {
      this.livroService.inserirLivro().subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          this.loadAllLivros();
          this.livroIdUpdate = null;
          this.livroForm.reset();
        }
      );
    } else {
      livro.Id = this.livroIdUpdate;
      this.livroService.alterarLivro().subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllLivros();
        this.livroIdUpdate = null;
        this.livroForm.reset();
      });
    }
  }

  deleteEmployee(livroId: number) {
    if (confirm("Are you sure you want to delete this ?")) {
      this.livroService.removerLivro(livroId).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllLivros();
        this.livroIdUpdate = null;
        this.livroForm.reset();

      });
    }
  }
  resetForm() {
    this.livroForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }
}