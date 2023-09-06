import axios from "axios";
import type {
  PrinterMetrics,
  PrinterAgent,
  Patient,
  CreatePrescription,
  Prescription,
  CreatePrintJob,
} from "./types";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? "http://localhost:5091/",
});

export const getPrinterMetrics = () => api.get<PrinterMetrics>("/printer-metrics").then((res) => res.data);

export const getPrinterAgents = () => api.get<PrinterAgent[]>("/printer-agents").then((res) => res.data);

export const getPatients = () => api.get<Patient[]>("/patients").then((res) => res.data);

export const getPrescriptions = () => api.get<Prescription[]>("/prescriptions").then((res) => res.data);

export const postPrescriptions = (data: CreatePrescription) =>
  api.post("/prescriptions", data).then((res) => res.data);

export const postPrintJob = (data: CreatePrintJob) => api.post("/print-jobs", data).then((res) => res.data);
