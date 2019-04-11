import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { LivroDetailService } from 'src/app/Services/livro-detail.service';

import { LivroDetail } from 'src/app/Models/livro-detail.models';


@Component({
  selector: 'app-livro-detail-list',
  templateUrl: './livro-detail-list.component.html',
  styles: []
})
export class LivroDetailListComponent implements OnInit {

  constructor(private service: LivroDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(pd: LivroDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(Id) {
    if (confirm('Tem certeza que deseja apagar esse registro?')) {
      this.service.deleteDetail(Id)
        .subscribe(res => {
          //debugger;
          this.service.refreshList();
          this.toastr.warning('Apagado com sucesso', 'Cadastro Livro');
        },
          err => {
            //debugger;
            console.log(err);
          })
    }
  }

}