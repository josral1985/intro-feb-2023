import { StringCalculator } from './string-calculator';

describe('String Calculator', () => {
  it('Empty String Returns Zero', () => {
    const calculator = new StringCalculator();

    let result = calculator.add('');

    expect(result).toEqual(0);
  });

  describe('Single Digits', () => {
    let calculator: StringCalculator;

    beforeEach(() => {
      calculator = new StringCalculator();
    });

    it('First', () => {
      const result = calculator.add('1');
      expect(result).toEqual(1);
    });

    it('Second', () => {
      const result = calculator.add('2');
      expect(result).toEqual(2);
    });

    it('Third', () => {
      const result = calculator.add('3');
      expect(result).toEqual(3);
    });
  });

  describe('Double Digits', () => {
    let calculator: StringCalculator;

    beforeEach(() => {
      calculator = new StringCalculator();
    });

    it('First', () => {
      const result = calculator.add('1,2');
      expect(result).toEqual(3);
    });

    it('Second', () => {
      const result = calculator.add('3,4');
      expect(result).toEqual(7);
    });

    it('Third', () => {
      const result = calculator.add('10,20');
      expect(result).toEqual(30);
    });
  });
});
