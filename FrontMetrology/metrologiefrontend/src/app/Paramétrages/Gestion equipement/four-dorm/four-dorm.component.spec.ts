import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FourDormComponent } from './four-dorm.component';

describe('FourDormComponent', () => {
  let component: FourDormComponent;
  let fixture: ComponentFixture<FourDormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FourDormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FourDormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
