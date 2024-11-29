import { createContext, ReactNode } from "react";
import { Api } from "../api/Api";

export const ApiContextContext = createContext(new Api())

export const ApiContext = ({children}:{children:ReactNode}) => {
    return <ApiContextContext.Provider value={new Api()}>
        {children}
    </ApiContextContext.Provider>
}