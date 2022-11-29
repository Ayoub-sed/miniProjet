import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebimetreMassiqueFormComponent } from './debimetre-massique-form.component';

describe('DebimetreMassiqueFormComponent', () => {
  let component: DebimetreMassiqueFormComponent;
  let fixture: ComponentFixture<DebimetreMassiqueFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebimetreMassiqueFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DebimetreMassiqueFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
