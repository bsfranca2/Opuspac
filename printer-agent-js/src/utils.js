const fs = require("fs");

/**
 * @param {string} filePath
 */
const fileToJson = (filePath) => {
  const data = fs.readFileSync(filePath, "utf-8");
  return JSON.parse(data);
};

/**
 * @param {string} value
 */
const normalizeCom = (value) => {
  return value.includes("\\\\.\\") ? value : `\\\\.\\${value}`;
};

const PrintJobStatus = {
  Waiting: 0,
  Running: 1,
  Done: 2,
  Error: 3,
};

module.exports = {
  fileToJson,
  normalizeCom,
  PrintJobStatus,
};
