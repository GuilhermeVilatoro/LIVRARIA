import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Livro } from '../Models/livro.models';

import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class LivroService {
  formData: Livro;
  readonly rootURL = environment.API_URL;

  constructor(private http: HttpClient) { }

  ListarLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.rootURL + '/Livro');
  }

  getLivroById() {
    return this.http.get<Livro>(this.rootURL + '/Livro/' + this.formData.Id);
  }

  inserirLivro() {
    return this.http.post(this.rootURL + '/Livro', this.formData);
  }

  alterarLivro() {
    return this.http.put(this.rootURL + '/Livro/' + this.formData.Id, this.formData);
  }

  removerLivro(id) {
    return this.http.delete(this.rootURL + '/Livro/' + id);
  }
}
