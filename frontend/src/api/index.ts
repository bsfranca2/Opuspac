import axios from "axios";
import type { PrinterMetrics, PrinterAgent } from "./types";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL ?? "http://localhost:5091/",
});

export const getPrinterMetrics = () => api.get<PrinterMetrics>("/printer-metrics").then((res) => res.data);

export const getPrinterAgents = () => api.get<PrinterAgent[]>("/printer-agents").then((res) => res.data);
