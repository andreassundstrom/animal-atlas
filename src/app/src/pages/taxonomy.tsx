import { Box, Dialog, DialogContent, DialogTitle, List, ListItem, Typography } from "@mui/material"
import { useEffect, useState } from "react"
import { Api } from "../api/Api"
import { GetTaxonomyItemDto } from "../api/data-contracts"
import { TaxonomyItemTreeNode } from "../components/taxonomyItemTreeNode"
import { TaxonomyContext } from "../contexts/TaxonomyContext"
import { useTaxonomyContext } from "../hooks/useTaxonomyContext"

const TaxonomyListBase = () => {
    const api = new Api()
    const [taxonomyList, setTaxonomyList ] = useState<GetTaxonomyItemDto[]>()
    
    const {action, setAction} = useTaxonomyContext()
    
    useEffect(() => {
        api
        .v1TaxonomyItemsList()
        .then(res => setTaxonomyList(res.data))
    },[])

    return <>
    {action?.action === "addChild" && 
    <Dialog open onClose={() => setAction(null)}>
        <DialogContent>
            <DialogTitle>Add child to {action.taxonomyItemId}</DialogTitle>
        </DialogContent>
        </Dialog>}
    <Typography>Items: </Typography>
    <List>
    {taxonomyList && taxonomyList.map((map) =>
        <TaxonomyItemTreeNode key={map.taxonomyItemId} taxonomyItem={map} />)}
</List></>
}

export const Taxonomy = () => {
    
    return <Box>
        <Typography>Taxonomy items</Typography>
        <TaxonomyContext>
        <TaxonomyListBase />
    </TaxonomyContext>
        </Box>
}