export class NoNegativesAllowedExecption extends Error {
  __proto__ = Error;

  constructor(msg: string) {
    super(msg);
    Object.setPrototypeOf(this, NoNegativesAllowedExecption.prototype);
  }
}
