import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { AutorDetail } from '../Models/autor-detail.models';
import { ResultService } from '../Models/result-service.models';

@Injectable({
  providedIn: 'root'
})
export class AutorDetailService {
  formData: AutorDetail;
  readonly rootURL = environment.API_URL;
  list: AutorDetail[];

  constructor(private http: HttpClient) { }

  postDetail() {
    return this.http.post(this.rootURL + '/Autor', this.formData);
  }

  putDetail() {
    return this.http.put(this.rootURL + '/Autor/' + this.formData.Id, this.formData);
  }
  deleteDetail(id) {
    return this.http.delete(this.rootURL + '/Autor/' + id);
  }

  refreshList() {
    this.getList()
      .then(res => this.list = (res as ResultService).data as AutorDetail[]);
  }

  getList()
  {
    return this.http.get(this.rootURL + '/Autor')
      .toPromise();
  }
}