import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LivroComponent } from './Components/livro/livro.component';
import { AutorComponent } from './Components/autor/autor.component';
import { UsuarioComponent } from './Components/usuario/usuario.component';

import { LivroService } from './Services/livro.service';
import { AutorService } from './Services/autor.service';
import { UsuarioService } from './Services/usuario.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {
  MatButtonModule,
  MatMenuModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatIconModule,
  MatCardModule,
  MatSidenavModule,
  MatFormFieldModule,
  MatInputModule,
  MatTooltipModule,
  MatToolbarModule
} from '@angular/material';

import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    LivroComponent,
    AutorComponent,
    UsuarioComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatRadioModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule
  ],
  providers: [
    HttpClientModule,
    LivroService,
    AutorService,
    UsuarioService,
    MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
