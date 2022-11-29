import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EtuveFormComponent } from './etuve-form.component';

describe('EtuveFormComponent', () => {
  let component: EtuveFormComponent;
  let fixture: ComponentFixture<EtuveFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EtuveFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EtuveFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
