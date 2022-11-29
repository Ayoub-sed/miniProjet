import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhMetreComponent } from './ph-metre.component';

describe('PhMetreComponent', () => {
  let component: PhMetreComponent;
  let fixture: ComponentFixture<PhMetreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhMetreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhMetreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
