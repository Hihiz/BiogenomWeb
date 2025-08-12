import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { VitaminOutput } from '../../models/output/vitamin-output';
import { VitaminService } from '../../services/vitamin.service';
import { Router } from '@angular/router';
import { NgFor } from '@angular/common';

/**
 * Класс компонента витамина.
 */
@Component({
  selector: 'app-vitamin',
  standalone: true,
  imports: [NgFor],
  templateUrl: './vitamin.component.html',
  styleUrl: './vitamin.component.css',
})
export class VitaminComponent implements OnInit {
  public readonly vitamins$ = new BehaviorSubject<VitaminOutput[]>([]);

  /**
   * Конструктор.
   * @param _router Роутер.
   * @param _vitaminService Сервис витаминов.
   */
  constructor(
    private readonly _router: Router,
    private readonly _vitaminService: VitaminService
  ) {
    this.vitamins$ = this._vitaminService.vitamins$;
  }

  public async ngOnInit() {
    // Список с витаминами загружается один раз.
    if (this.vitamins$.value.length <= 0) {
      await this.getVitaminsAsync();
    }

    console.log('Размер списка: ', this.vitamins$.value.length);
  }

  /**
   * Функция получает список витаминов.
   */
  private async getVitaminsAsync() {
    (await this._vitaminService.getVitaminsAsync()).subscribe((_) =>
      console.log(`Получен список витаминов: `, this.vitamins$.value)
    );
  }

  /**
   * Функция получает витамин по Id.
   * @param vitaminId Выбранный Id витамина.
   */
  public async onGetVitaminByVitaminId(vitaminId: number) {
    this._router.navigate(['/detail-vitamin'], {
      queryParams: {
        vitaminId,
      },
    });
  }

  /**
   * Функция переходит на страницу создания витамина.
   */
  public onCreateVitamin() {
    this._router.navigate(['/create-vitamin']);
  }

  /**
   * Функция переходит на страницу редактирования витамина.
   * @param vitaminId Id витамина.
   */
  public onUpdateVitamin(vitaminId: number) {
    this._router.navigate(['/update-vitamin'], {
      queryParams: {
        vitaminId,
      },
    });
  }

  /**
   * Функция удаляет витамин.
   * @param selectedVitaminId Id витамина.
   */
  public async onRemoveVitaminAsync(selectedVitaminId: number) {
    (
      await this._vitaminService.removeVitaminAsync(selectedVitaminId)
    ).subscribe(async (_) => {
      console.log('Витамин удален.');
      console.log('Размер списка: ', this.vitamins$.value.length);
    });
  }

  /**
   * Функция переходит на страницу с результатами диагностики.
   */
  public onGetVitaminReports() {
    this._router.navigate(['/']);
  }
}
