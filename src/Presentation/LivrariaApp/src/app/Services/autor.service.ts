import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Autor } from '../Models/autor.models';

import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AutorService {
  formData: Autor;
  readonly rootURL = environment.API_URL;
  
  constructor(private http: HttpClient) { }

  ListarAutores(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.rootURL + '/Autor');
  }

  getAutorById() {
    return this.http.get<Autor>(this.rootURL + '/Autor/' + this.formData.Id);
  }

  inserirAutor() {
    return this.http.post(this.rootURL + '/Autor', this.formData);
  }

  alterarAutor() {
    return this.http.put(this.rootURL + '/Autor/' + this.formData.Id, this.formData);
  }

  removerAutor(id) {
    return this.http.delete(this.rootURL + '/Autor/' + id);
  }
}