import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseFilialeComponent } from './choose-filiale.component';

describe('ChooseFilialeComponent', () => {
  let component: ChooseFilialeComponent;
  let fixture: ComponentFixture<ChooseFilialeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChooseFilialeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseFilialeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
