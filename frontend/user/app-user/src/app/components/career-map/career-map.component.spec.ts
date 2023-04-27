import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareerMapComponent } from './career-map.component';

describe('CareerMapComponent', () => {
  let component: CareerMapComponent;
  let fixture: ComponentFixture<CareerMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CareerMapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CareerMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
