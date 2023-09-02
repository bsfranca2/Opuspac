namespace Opuspac.Api.Models.Response;

public record PrinterMetricsResponseModel(int PrinterAgentsConnected, int PrintJobsWaiting, int PrintJobsError);