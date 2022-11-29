import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetFraisInterventionComponent } from './get-frais-intervention.component';

describe('GetFraisInterventionComponent', () => {
  let component: GetFraisInterventionComponent;
  let fixture: ComponentFixture<GetFraisInterventionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetFraisInterventionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetFraisInterventionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
