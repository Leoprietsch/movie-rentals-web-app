import http from "../http-common";

export const exportReport = () => http.get("/report", { responseType: "blob" });
