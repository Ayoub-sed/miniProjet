import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BainFormComponent } from './bain-form.component';

describe('BainFormComponent', () => {
  let component: BainFormComponent;
  let fixture: ComponentFixture<BainFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BainFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BainFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
