import Locacao from "../entities/Locacao";
import http from "../http-common";

export const getAll = () => http.get<Array<Locacao>>("/rent");
