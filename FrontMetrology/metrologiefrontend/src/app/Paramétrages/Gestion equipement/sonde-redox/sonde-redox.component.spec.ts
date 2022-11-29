import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SondeRedoxComponent } from './sonde-redox.component';

describe('SondeRedoxComponent', () => {
  let component: SondeRedoxComponent;
  let fixture: ComponentFixture<SondeRedoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SondeRedoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SondeRedoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
