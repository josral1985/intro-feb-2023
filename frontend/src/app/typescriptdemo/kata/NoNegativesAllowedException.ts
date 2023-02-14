export class NoNegativesAllowedException extends Error {
  __proto__ = Error;

  constructor(msg: string) {
    super(msg);
    Object.setPrototypeOf(this, NoNegativesAllowedException.prototype);
  }
}
