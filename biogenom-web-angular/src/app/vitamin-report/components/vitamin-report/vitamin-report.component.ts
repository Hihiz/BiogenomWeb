import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { VitaminReportService } from '../../services/vitamin-report.service';
import { NgFor, NgIf } from '@angular/common';
import { VitaminReportOutput } from '../../models/output/vitamin-report-output';

/**
 * Класс компонента отчетов диагностики пользователя.
 */
@Component({
  selector: 'app-vitamin-report',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './vitamin-report.component.html',
  styleUrl: './vitamin-report.component.css',
})
export class VitaminReportComponent implements OnInit {
  public readonly vitaminReports$ = new BehaviorSubject<VitaminReportOutput[]>(
    []
  );

  /**
   * Конструктор.
   * @param _router Роутер.
   * @param _vitaminReportService Сервис о отчета диагностики пользователя.
   */
  constructor(
    private readonly _router: Router,
    private readonly _vitaminReportService: VitaminReportService
  ) {
    this.vitaminReports$ = this._vitaminReportService.vitaminReports$;
  }

  public async ngOnInit() {
    if (this.vitaminReports$.value.length <= 0) {
      await this.getVitaminsReportAsync();
    }
  }

  /**
   * Функция получает список результатов диагностики.
   */
  private async getVitaminsReportAsync() {
    let result = await this._vitaminReportService.getVitaminReportsAsync();
    result.subscribe((_) =>
      console.log(`Получен список результатов диагностики`,this.vitaminReports$.value)
    
    );
  }

  /**
   * Функция получает выбранный результат диагностики отчета.
   * @param vitaminReportId Выбранный Id результата диагностики.
   */
  public onGetVitaminReportById(vitaminReportId: number) {
    console.log(`Выбранный результат диагностики: `, vitaminReportId);
    this._router.navigate([`/detail-vitamin-report`], {
      queryParams: {
        vitaminReportId,
      },
    });
  }

  /**
   * Функция переходит на страницу витаминов.
   */
  public onGetVitamins() {
    this._router.navigate(['/vitamins']);
  }
}
