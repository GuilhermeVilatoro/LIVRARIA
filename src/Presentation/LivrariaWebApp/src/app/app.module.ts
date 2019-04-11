import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';

import { AutorDetailsComponent } from './autor-details/autor-details.component';
import { AutorDetailComponent } from './autor-details/autor-detail/autor-detail.component';
import { AutorDetailListComponent } from './autor-details/autor-detail-list/autor-detail-list.component';

import { LivroDetailsComponent } from './livro-details/livro-details.component';
import { LivroDetailComponent } from './livro-details/livro-detail/livro-detail.component';
import { LivroDetailListComponent } from './livro-details/livro-detail-list/livro-detail-list.component';

import { AutorDetailService } from './Services/autor-detail.service';
import { LivroDetailService } from './Services/livro-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    AutorDetailsComponent,
    AutorDetailComponent,
    AutorDetailListComponent,
    LivroDetailsComponent,
    LivroDetailComponent,
    LivroDetailListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AutorDetailService,
    LivroDetailService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
