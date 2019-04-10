import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Usuario } from '../Models/usuario.models';

import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService {
  formData: Usuario;
  readonly rootURL = environment.API_URL;

  constructor(private http: HttpClient) { }

  ListarUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.rootURL + '/Usuario');
  }

  getUsuarioById() {
    return this.http.get<Usuario>(this.rootURL + '/Usuario/' + this.formData.Id);
  }

  inserirUsuario() {
    return this.http.post(this.rootURL + '/Usuario', this.formData);
  }

  alterarUsuario() {
    return this.http.put(this.rootURL + '/Usuario/' + this.formData.Id, this.formData);
  }
}