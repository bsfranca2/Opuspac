class PrescriptionBuilder {
  /**
   * @type {import('node-thermal-printer').ThermalPrinter} printer
   */
  #printer;

  #firstMedicine = true;

  constructor(printer) {
    this.#printer = printer;
  }

  /**
   * Add qr code, prescription code and timestamp
   * @param {string} prescriptionCode
   */
  addHeader(prescriptionCode) {
    const _prescriptionCode = `PRESC1-${prescriptionCode}`;
    this.#printer.alignCenter();
    this.#printer.printQR(_prescriptionCode, {
      cellSize: 7,
      correction: "Q",
      model: 2,
    });

    this.#printer.newLine();
    this.#printer.bold(true);
    this.#printer.println(`Prescrição nº ${_prescriptionCode}`);
    this.#printer.bold(false);
    this.#printer.setTypeFontB();
    this.#printer.println(this.#getTimestamp());
    this.#printer.setTypeFontA();
    this.#printer.newLine();
    return this;
  }

  /**
   * Field inline with bold fieldName and regular fieldValue
   * @param {string} fieldName
   * @param {string} fieldValue
   */
  addField(fieldName, fieldValue) {
    this.#printer.alignLeft();
    this.#printer.bold(true);
    this.#printer.print(`${fieldName}: `);
    this.#printer.bold(false);
    this.#printer.println(this.#formatFieldValue(fieldValue));
    return this;
  }

  /**
   * @param {string} name
   * @param {number} quantity
   * @param {string} instruction
   */
  addMedicine(name, quantity, instructions) {
    if (this.#firstMedicine) {
      this.#printer.drawLine();
      this.#firstMedicine = false;
    }
    this.#printer.println(
      `${quantity.toString().padStart(2, "0")}x ${name.toUpperCase()}`
    );
    this.#printer.setTypeFontB();
    this.#printer.println(instructions.toUpperCase());
    this.#printer.setTypeFontA();
    return this;
  }

  addNewLine() {
    this.#printer.newLine();
    return this;
  }

  build() {
    this.#printer.cut();
    this.#printer.openCashDrawer();
    return this.#printer;
  }

  #getTimestamp() {
    const now = new Date();
    const formatter = new Intl.DateTimeFormat("pt-BR", {
      year: "numeric",
      month: "2-digit",
      day: "2-digit",
      hour: "2-digit",
      minute: "2-digit",
      second: "2-digit",
    });
    return formatter.format(now);
  }

  #formatFieldValue(value) {
    if (typeof value === "string" && !value.includes("hrs"))
      return value.toUpperCase();
    return value;
  }
}

module.exports = {
  PrescriptionBuilder,
};
