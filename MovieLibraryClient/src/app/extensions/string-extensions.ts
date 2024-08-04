declare global {
    interface String {
        firstLetterToUpperCase(): string;
    }
}
String.prototype.firstLetterToUpperCase = function (): string {
    return this.charAt(0).toUpperCase() + this.slice(1);
};