import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransmtteurDePressionComponent } from './transmtteur-de-pression.component';

describe('TransmtteurDePressionComponent', () => {
  let component: TransmtteurDePressionComponent;
  let fixture: ComponentFixture<TransmtteurDePressionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransmtteurDePressionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransmtteurDePressionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
