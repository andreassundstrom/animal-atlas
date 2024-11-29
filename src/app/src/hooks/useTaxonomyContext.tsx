import { useContext } from "react"
import { TaxonomyContextContext } from "../contexts/TaxonomyContext"

export const useTaxonomyContext = () => {
    const context = useContext(TaxonomyContextContext)
    return {action: context.action, setAction: context?.setAction}
}