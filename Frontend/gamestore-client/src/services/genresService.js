import api from "./api";
export async function getAllGenres() { const response = await api.get("/genres");
    return response.data;
}