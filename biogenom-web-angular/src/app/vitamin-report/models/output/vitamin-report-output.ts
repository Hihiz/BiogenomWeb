import { VitaminOutput } from "../../../vitamin/models/output/vitamin-output";

/**
 * Класс выходной модели отчета диагностики.
 */
export class VitaminReportOutput {
  /**
   * Id отчета диагностики.
   */
  id: number = 0;

  /**
   * Id отчета.
   */
  reportId: number = 0;

  /**
   * Id витамина.
   */
  vitaminId: number = 0;

  /**
   * Витамин.
   */
  vitamin: VitaminOutput = new VitaminOutput;

  /**
   * Текущее значение.
   */
  currentValue: number = 0;

  /**
   * Норма.
   */
  referenceValue: number = 0;

  /**
   * Значение витамина/минерала которое можно получить из питания.
   */
  foodValue: number = 0;

  /**
   * Значение витамина/минерала которое можно получить из набора (БАДов).
   */
  supplementValue: number = 0;

  /**
   * Снижено ли значение витамина/минерала.
   */
  isDeficit: boolean = false;
}
