/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

import {
  CreateTaxonomyGroupDto,
  CreateTaxonomyItemDto,
  GetTaxonomyGroupDto,
  GetTaxonomyItemDto,
} from "./data-contracts";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class Api<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags TaxonomyGroups
   * @name V1TaxonomyGroupsList
   * @request GET:/api/v1/taxonomy-groups
   */
  v1TaxonomyGroupsList = (params: RequestParams = {}) =>
    this.request<GetTaxonomyGroupDto[], any>({
      path: `/api/v1/taxonomy-groups`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyGroups
   * @name V1TaxonomyGroupsCreate
   * @request POST:/api/v1/taxonomy-groups
   */
  v1TaxonomyGroupsCreate = (data: CreateTaxonomyGroupDto, params: RequestParams = {}) =>
    this.request<GetTaxonomyGroupDto, any>({
      path: `/api/v1/taxonomy-groups`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyGroups
   * @name V1TaxonomyGroupsDetail
   * @request GET:/api/v1/taxonomy-groups/{id}
   */
  v1TaxonomyGroupsDetail = (id: number, params: RequestParams = {}) =>
    this.request<GetTaxonomyGroupDto, any>({
      path: `/api/v1/taxonomy-groups/${id}`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyGroups
   * @name V1TaxonomyGroupsUpdate
   * @request PUT:/api/v1/taxonomy-groups/{id}
   */
  v1TaxonomyGroupsUpdate = (id: number, data: CreateTaxonomyGroupDto, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/v1/taxonomy-groups/${id}`,
      method: "PUT",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyGroups
   * @name V1TaxonomyGroupsDelete
   * @request DELETE:/api/v1/taxonomy-groups/{id}
   */
  v1TaxonomyGroupsDelete = (id: number, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/v1/taxonomy-groups/${id}`,
      method: "DELETE",
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyItems
   * @name V1TaxonomyItemsList
   * @request GET:/api/v1/taxonomy-items
   */
  v1TaxonomyItemsList = (
    query?: {
      /** @format int32 */
      parentId?: number;
    },
    params: RequestParams = {},
  ) =>
    this.request<GetTaxonomyItemDto[], any>({
      path: `/api/v1/taxonomy-items`,
      method: "GET",
      query: query,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyItems
   * @name V1TaxonomyItemsCreate
   * @request POST:/api/v1/taxonomy-items
   */
  v1TaxonomyItemsCreate = (data: CreateTaxonomyItemDto, params: RequestParams = {}) =>
    this.request<void, any>({
      path: `/api/v1/taxonomy-items`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      ...params,
    });
  /**
   * No description
   *
   * @tags TaxonomyItems
   * @name V1TaxonomyItemsDetail
   * @request GET:/api/v1/taxonomy-items/{taxonomyItemId}
   */
  v1TaxonomyItemsDetail = (taxonomyItemId: number, params: RequestParams = {}) =>
    this.request<GetTaxonomyItemDto, any>({
      path: `/api/v1/taxonomy-items/${taxonomyItemId}`,
      method: "GET",
      format: "json",
      ...params,
    });
}
