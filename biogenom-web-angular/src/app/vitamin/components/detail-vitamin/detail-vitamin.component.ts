import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { VitaminOutput } from '../../models/output/vitamin-output';
import { VitaminService } from '../../services/vitamin.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { StorageService } from '../../../helpers/storage.serivce';

/**
 * Класс компонента деталей витамина.
 */
@Component({
  selector: 'app-detail-vitamin',
  standalone: true,
  imports: [NgIf],
  templateUrl: './detail-vitamin.component.html',
  styleUrl: './detail-vitamin.component.css',
})
export class DetailVitaminComponent implements OnInit {
  public readonly detailVitamin$ = new BehaviorSubject<VitaminOutput>(
    new VitaminOutput()
  );

  /**
   * Конструктор.
   * @param _router Роутер.
   * @param _vitaminService Сервис витаминов.
   * @param _activateRoute Роутер строки запроса.
   * @param _storageService Сервис хранения данных.
   */
  constructor(
    private readonly _router: Router,
    private readonly _vitaminService: VitaminService,
    private readonly _activateRoute: ActivatedRoute,
    private readonly _storageService: StorageService
  ) {
    this.detailVitamin$ = this._vitaminService.detailVitamin$;
  }

  vitaminId: number = 0;

  public async ngOnInit() {
    this.checkUrlParams();
    await this.getDetailVitaminAsync();
  }

  /**
   * Функция берет значение из параметров URL.
   */
  private checkUrlParams() {
    this._activateRoute.queryParams.subscribe((params) => {
      if (params['vitaminId']) {
        this.vitaminId = params['vitaminId'];
      }
    });
  }

  /**
   * Функция получает детали витамина.
   */
  private async getDetailVitaminAsync() {
    // (await this._vitaminService.getVitaminByVitaminIdAsync(this.vitaminId))
    // .subscribe((_) => {
    //   console.log("Детали витамина: ", this.detailVitamin$.value)
    // });

    // Проверяем есть ли в сторадже запись.
    const savedDetail =
      this._storageService.get<VitaminOutput>('detailVitamin');

    if (savedDetail && savedDetail.id == this.vitaminId) {
      this.detailVitamin$.next(savedDetail);
      return;
    }

    // Поиск в списке.
    const findDetail = this._vitaminService.vitamins$.value.find(
      (v) => v.id == this.vitaminId
    );

    if (!findDetail) {
      console.log('Витамин не найден.');
      return;
    }

    this.detailVitamin$.next(findDetail);

    // Сохраняем в сторадж, для получения после перезагрузки страницы.
    this._storageService.save<VitaminOutput>('detailVitamin', findDetail);

    console.log('Найденный витамин:', this.detailVitamin$.value);
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

      this._router.navigate(['/vitamins']);
    });
  }

  /**
   * Функция переходит к списку витаминов.
   */
  public onGetVitamins() {
    this._router.navigate(['/vitamins']);
  }
}
