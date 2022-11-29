import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FraisInterventionComponent } from './frais-intervention.component';

describe('FraisInterventionComponent', () => {
  let component: FraisInterventionComponent;
  let fixture: ComponentFixture<FraisInterventionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FraisInterventionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FraisInterventionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
