import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LivroDetailListComponent } from './livro-detail-list.component';

describe('LivroDetailListComponent', () => {
  let component: LivroDetailListComponent;
  let fixture: ComponentFixture<LivroDetailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LivroDetailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LivroDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
