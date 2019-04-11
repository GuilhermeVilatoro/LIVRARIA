import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AutorDetailService } from 'src/app/Services/autor-detail.service';
import { AutorDetail } from 'src/app/Models/autor-detail.models';

@Component({
  selector: 'app-autor-detail-list',
  templateUrl: './autor-detail-list.component.html',
  styles: []
})
export class AutorDetailListComponent implements OnInit {

  constructor(private service: AutorDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(pd: AutorDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(Id) {
    if (confirm('Tem certeza que deseja apagar esse registro?')) {
      this.service.deleteDetail(Id)
        .subscribe(res => {
          //debugger;
          this.service.refreshList();
          this.toastr.warning('Apagado com sucesso', 'Cadastro Autor');
        },
          err => {
            //debugger;
            console.log(err);
          })
    }
  }

}