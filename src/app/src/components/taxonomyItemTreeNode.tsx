import { IconButton, ListItem } from "@mui/material"
import { GetTaxonomyItemDto } from "../api/data-contracts"
import { useTaxonomyContext } from "../hooks/useTaxonomyContext"
type Props = {
    taxonomyItem: GetTaxonomyItemDto
}

export function TaxonomyItemTreeNode({taxonomyItem}:Props){
    const {action, setAction} = useTaxonomyContext()
    return <ListItem>{taxonomyItem.taxonomyItemName} <IconButton onClick={() => setAction({action: 'addChild', taxonomyItemId: taxonomyItem.taxonomyItemId ?? 0})}>Add</IconButton></ListItem>
}