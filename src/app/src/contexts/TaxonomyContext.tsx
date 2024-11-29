import { createContext, ReactNode, useState } from "react"

type TaxonomyContextProps = {
    action: TaxonomyContextAction | null
    setAction : React.Dispatch<React.SetStateAction<TaxonomyContextAction | null>>
}

type TaxonomyContextAction = {
    taxonomyItemId: number | null,
    action : 'addChild' | 'add' | 'edit' | null
}

export const TaxonomyContextContext = createContext<TaxonomyContextProps>({} as TaxonomyContextProps)

export const TaxonomyContext = ({children}: {children: ReactNode}) => {
    const [action, setAction] = useState<TaxonomyContextAction|null>(null)
    return <TaxonomyContextContext.Provider value={{action, setAction}}>
        {children}
    </TaxonomyContextContext.Provider>
}
