import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManometreDePressionComponent } from './manometre-de-pression.component';

describe('ManometreDePressionComponent', () => {
  let component: ManometreDePressionComponent;
  let fixture: ComponentFixture<ManometreDePressionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManometreDePressionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManometreDePressionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
