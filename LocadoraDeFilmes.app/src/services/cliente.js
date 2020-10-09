import { http } from "./config";

export default {
  salvar: (category) => {
    return http.post("category", category);
  },

  atualizar: (category) => {
    return http.put("category", category);
  },

  listar: () => {
    return http.get("category");
  },

  apagar: (category) => {
    return http.delete("category", { data: category });
  },
};
