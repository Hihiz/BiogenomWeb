import { Component } from '@angular/core';
import { VitaminService } from '../../services/vitamin.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

/**
 * Класс компонента добавления витамина.
 */
@Component({
  selector: 'app-create-vitamin',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-vitamin.component.html',
  styleUrl: './create-vitamin.component.css',
})
export class CreateVitaminComponent {
  /**
   * Конструктор.
   * @param _vitaminService Сервис витамина.
   * @param _router Роутер.
   */
  constructor(
    private readonly _vitaminService: VitaminService,
    private readonly _router: Router
  ) {}

  vitaminTitle: string = '';

  /**
   * Функция добавляет витамин.
   */
  public async onCreateVitaminAsync() {
    (
      await this._vitaminService.createVitaminAsync(this.vitaminTitle)
    ).subscribe((_) => {
      console.log('Витамин создан');

      // Очищаем поля после создания.
      this.vitaminTitle = '';

      this.onGetVitamins();
    });
  }

  /**
   * Функция переходит на страницу с витамина.
   */
  public onGetVitamins() {
    this._router.navigate(['/vitamins']);
  }
}
