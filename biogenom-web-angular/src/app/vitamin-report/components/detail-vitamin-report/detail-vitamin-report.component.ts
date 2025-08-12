import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { VitaminReportService } from '../../services/vitamin-report.service';
import { VitaminReportOutput } from '../../models/output/vitamin-report-output';
import { NgIf } from '@angular/common';
import { StorageService } from '../../../helpers/storage.serivce';

/**
 * Класс компонента деталей отчетов диагностики пользователя.
 */
@Component({
  selector: 'app-detail-vitamin-report',
  standalone: true,
  imports: [NgIf],
  templateUrl: './detail-vitamin-report.component.html',
  styleUrl: './detail-vitamin-report.component.css',
})
export class DetailVitaminReportComponent implements OnInit {
  private readonly vitaminReports$ = new BehaviorSubject<VitaminReportOutput[]>(
    []
  );

  /**
   * Конструктор.
   * @param _route Роутер.
   * @param _vitaminReportService Сервис отчетов диагностики пользователя.
   */
  constructor(
    private readonly _router: Router,
    private readonly _vitaminReportService: VitaminReportService,
    private readonly _activateRoute: ActivatedRoute,
    private readonly _storageService: StorageService
  ) {
    this.vitaminReports$ = this._vitaminReportService.vitaminReports$;
  }

  vitaminReportId: number = 0;
  detailVitaminReport: VitaminReportOutput = new VitaminReportOutput();

  public async ngOnInit() {
    this.checkUrlParams();
    this.getDetailVitaminReport();
  }

  /**
   * Функция берет значения из параметров URL.
   */
  private checkUrlParams() {
    this._activateRoute.queryParams.subscribe((params) => {
      if (params['vitaminReportId']) {
        this.vitaminReportId = params['vitaminReportId'];
      }
    });
  }

  /**
   * Функция получает детали отчета диагностики.
   * @returns Детали отчета диагностики.
   */
  private getDetailVitaminReport() {
    // Проверяем есть ли в сторадже запись.
    const savedDetail =
      this._storageService.get<VitaminReportOutput>('detailVitaminReport');

    // Проверяем соответствие по Id.
    if (savedDetail &&
        savedDetail.id == this.vitaminReportId) {
          this.detailVitaminReport = savedDetail!;
          return;
    }

    // Иначе ищем в текущих данных.
    const findDetail = this.vitaminReports$.value.find(
      (r) => r.id == this.vitaminReportId
    );

    if (!findDetail) {
      console.log("Отчет диагностики не найден.")
      return;
    }

    this.detailVitaminReport = findDetail;
    // Сохраняем в сторадж, для получения после перезагрузки страницы.
    this._storageService.save<VitaminReportOutput>('detailVitaminReport', findDetail);

    console.log('Найденный отчет:', this.detailVitaminReport);
  }

  /**
   * Функция переходит к списку результатов диагностики.
   */
  public onGetVitaminReports() {
    this._router.navigate(['/']);
  }
}
