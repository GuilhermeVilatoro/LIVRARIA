import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { AutorDetail } from 'src/app/Models/autor-detail.models';
import { AutorDetailService } from 'src/app/Services/autor-detail.service';

import { ResultService } from 'src/app/Models/result-service.models';
import { LivroDetailService } from 'src/app/Services/livro-detail.service';

@Component({
  selector: 'app-livro-detail',
  templateUrl: './livro-detail.component.html',
  styles: []
})
export class LivroDetailComponent implements OnInit {
  autorList: AutorDetail[];

  constructor(private service: LivroDetailService,
    private autorService: AutorDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      Id: 0,
      Titulo: '',
      NumeroDePaginas: null,
      Edicao: null,
      Ano: null,
      Descricao: '',
      AutorId: null
    }

    this.autorService.getList().then(res => this.autorList = (res as ResultService).data as AutorDetail[]);
    //debugger;
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.Id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postDetail().subscribe(
      res => {
        //debugger;
        this.resetForm(form);
        this.toastr.success('Incluido com sucesso', 'Livro Criado');
        this.service.refreshList();
      },
      err => {
        //debugger;
        console.log(err);
      }
    )
  }
  updateRecord(form: NgForm) {
    this.service.putDetail().subscribe(
      res => {
        //debugger;
        this.resetForm(form);
        this.toastr.info('Alterado com sucesso', 'Livro Alterado');
        this.service.refreshList();
      },
      err => {
        //debugger;
        console.log(err);
      }
    )
  }

}
