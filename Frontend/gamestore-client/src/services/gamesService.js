import api from "./api";
export const getAllGames = async() => { const response = await api.get("/games");
    return response.data;
};
export async function deleteGame(id) { const response = await api.delete(`/games/${id}`); 
return response.data;
};
export async function createGame(game) { const response = await api.post("/games", game);
    return response.data;
};
export async function  updateGame(id, game) {
  const response = await api.put(`/games/${id}`, game);
  return response.data;
}