import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { AutorDetailService } from 'src/app/Services/autor-detail.service';

@Component({
  selector: 'app-autor-detail',
  templateUrl: './autor-detail.component.html',
  styles: []
})
export class AutorDetailComponent implements OnInit {

  constructor(private service: AutorDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      Id: 0,
      Nome: '',
      Sobrenome: ''      
    }
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
        this.toastr.success('Incluido com sucesso', 'Autor Criado');
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
        this.toastr.info('Alterado com sucesso', 'Autor Alterado');
        this.service.refreshList();
      },
      err => {
        //debugger;
        console.log(err);
      }
    )
  }
}
