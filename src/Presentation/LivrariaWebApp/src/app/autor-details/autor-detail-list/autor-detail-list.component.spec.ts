import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AutorDetailListComponent } from './autor-detail-list.component';

describe('AutorDetailListComponent', () => {
  let component: AutorDetailListComponent;
  let fixture: ComponentFixture<AutorDetailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutorDetailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutorDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
