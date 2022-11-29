import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnsacheuseFormComponent } from './ensacheuse-form.component';

describe('EnsacheuseFormComponent', () => {
  let component: EnsacheuseFormComponent;
  let fixture: ComponentFixture<EnsacheuseFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnsacheuseFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnsacheuseFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
