import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VitaminService } from '../../services/vitamin.service';
import { VitaminOutput } from '../../models/output/vitamin-output';
import { UpdateVitaminInput } from '../../models/input/update-vitamin-input';
import { StorageService } from '../../../helpers/storage.serivce';

/**
 * Класс компонента редактирования витамина.
 */
@Component({
  selector: 'app-update-vitamin',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update-vitamin.component.html',
  styleUrl: './update-vitamin.component.css',
})
export class UpdateVitaminComponent implements OnInit {
  /**
   * Конструктор.
   * @param _router Роутер.
   * @param _activatedRoute Роутер строки запроса.
   * @param _vitaminService Сервис витаминов.
   */
  constructor(
    private readonly _router: Router,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _vitaminService: VitaminService,
    private readonly _storageService: StorageService
  ) {}

  vitaminId: number = 0;
  vitaminTitle: string = '';

  public async ngOnInit() {
    this.checkUrlParams();
    await this.getVitaminByVitaminIdAsync();
  }

  /**
   * Функция берет значения из параметров URL.
   */
  private checkUrlParams() {
    this._activatedRoute.queryParams.subscribe((params) => {
      if (params['vitaminId']) {
        this.vitaminId = params['vitaminId'];
      }
    });
  }

  /**
   * Функция заполняет поля перед редактированием.
   */
  private async getVitaminByVitaminIdAsync() {   
    // Проверяем есть ли в сторадже запись.
    const savedDetail =
      this._storageService.get<VitaminOutput>('detailVitamin');

    if (savedDetail && savedDetail.id == this.vitaminId) {
      this.vitaminId = savedDetail.id;
      this.vitaminTitle = savedDetail.title;
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

    this.vitaminId = findDetail.id;
    this.vitaminTitle = findDetail.title;

    // Сохраняем в сторадж, для получения после перезагрузки страницы.
    this._storageService.save<VitaminOutput>('detailVitamin', findDetail);

    console.log('Найденный витамин:', findDetail);
  }

  /**
   * Функция редактирует витамин.
   */
  public async onUpdateVitaminAsync() {
    const vitamininput: UpdateVitaminInput = new UpdateVitaminInput();

    if (this.vitaminId != null
       && this.vitaminId !== 0) {
      vitamininput.id = this.vitaminId;
    }

    if (this.vitaminTitle != null && 
      this.vitaminTitle !== '') {
      vitamininput.title = this.vitaminTitle;
    }

    (await this._vitaminService.updateVitaminAsync(vitamininput)).subscribe(
      (_) => {
        console.log('Витамин обновлен');

        this.vitaminId = 0;
        this.vitaminTitle = '';

        this._storageService.clean();

        // Получаем актуальный список витаминов.
        this._router.navigate(['/vitamins']);
      }
    );
  }

  /**
   * Функция переходит к списку витаминов.
   */
  public onGetVitamins() {
    this._router.navigate(['/vitamins']);
  }
}
