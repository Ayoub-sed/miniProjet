import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConductivimetreFormComponent } from './conductivimetre-form.component';

describe('ConductivimetreFormComponent', () => {
  let component: ConductivimetreFormComponent;
  let fixture: ComponentFixture<ConductivimetreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConductivimetreFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConductivimetreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
