import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CapteurDePressionFormComponent } from './capteur-de-pression-form.component';

describe('CapteurDePressionFormComponent', () => {
  let component: CapteurDePressionFormComponent;
  let fixture: ComponentFixture<CapteurDePressionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CapteurDePressionFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CapteurDePressionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
