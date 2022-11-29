import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFraisInterventionComponent } from './list-frais-intervention.component';

describe('ListFraisInterventionComponent', () => {
  let component: ListFraisInterventionComponent;
  let fixture: ComponentFixture<ListFraisInterventionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListFraisInterventionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListFraisInterventionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
