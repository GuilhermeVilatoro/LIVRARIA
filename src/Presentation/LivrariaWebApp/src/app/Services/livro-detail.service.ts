import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

import { LivroDetail } from '../Models/livro-detail.models';
import { ResultService } from '../Models/result-service.models';

@Injectable({
  providedIn: 'root'
})
export class LivroDetailService {
  formData: LivroDetail;
  readonly rootURL = environment.API_URL;
  list: LivroDetail[];

  constructor(private http: HttpClient) { }

  postDetail() {
    return this.http.post(this.rootURL + '/Livro', this.formData);
  }

  putDetail() {
    return this.http.put(this.rootURL + '/Livro/' + this.formData.Id, this.formData);
  }
  deleteDetail(id) {
    return this.http.delete(this.rootURL + '/Livro/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL + '/Livro')
      .toPromise()
      .then(res => this.list = (res as ResultService).data as LivroDetail[]);
  }
}