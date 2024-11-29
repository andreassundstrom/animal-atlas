import { useContext } from "react"
import { ApiContextContext } from "../contexts/ApiContext"

export const useApi = () => {
    const api = useContext(ApiContextContext)
    return api
}